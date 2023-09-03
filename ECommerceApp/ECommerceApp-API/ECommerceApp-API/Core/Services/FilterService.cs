﻿using ECommerceApp_API.Core.DTOs.FilterDTO;
using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp_API.Core.Services
{
    public class FilterService : IFilterService
    {
        public FilterSetDTO GetSendingFilter(ECommerceDbContext db, int subCategoryId)
        {
            FilterSetDTO sendingFilterDTO = new FilterSetDTO();

            var subCategory = db.SubCategories
                .Where(s => s.Id == subCategoryId)

                .Include(s => s.Products)
                .ThenInclude(p => p.Values)
                .ThenInclude(v => v.Attribute_AttributeSet)
                .ThenInclude(a => a.Attribute)

                .Include(s => s.Products)
                .ThenInclude(p => p.Values)
                .ThenInclude(v => v.Attribute_AttributeSet)
                .ThenInclude(a => a.AttributeSet);

            List<string> attrSets = new(), attrs = new(), values = new();
            SubCategory subCategory1 = subCategory.FirstOrDefault()!;
            List<Product> products = subCategory1.Products;
            foreach (var product in products)
            {
                foreach (var value in product.Values)
                {
                    AttributeSetFilter? attributeSetFilter = sendingFilterDTO.AttributeSetFilters
                        .Where(asf => asf.AttributeSetId == value.Attribute_AttributeSet.AttributeSetId)
                        .FirstOrDefault();
                    if (attributeSetFilter is null)
                    {
                        sendingFilterDTO.AttributeSetFilters.Add(new AttributeSetFilter()
                        {
                            AttributeSetId = value.Attribute_AttributeSet.AttributeSetId,
                            AttributeSetName = value.Attribute_AttributeSet.AttributeSet.Name,
                        });

                        attributeSetFilter = sendingFilterDTO.AttributeSetFilters[sendingFilterDTO.AttributeSetFilters.Count - 1];
                    }

                    AttributeFilter? attributeFilter = attributeSetFilter.AttributeFilters
                        .Where(af => af.AttributeId == value.Attribute_AttributeSet.AttributeId)
                        .FirstOrDefault();
                    if (attributeFilter is null)
                    {
                        if (value.Attribute_AttributeSet.Attribute.IsFilter)
                        {
                            attributeSetFilter.AttributeFilters.Add(new AttributeFilter()
                            {
                                AttributeId = value.Attribute_AttributeSet.AttributeId,
                                AttributeName = value.Attribute_AttributeSet.Attribute.Name
                            });

                            attributeFilter = attributeSetFilter.AttributeFilters[attributeSetFilter.AttributeFilters.Count - 1];
                        }
                    }

                    if (value.Attribute_AttributeSet.Attribute.IsFilter)
                    {
                        FilterValue? filterValue = attributeFilter!.Values
                        .Where(af => af.Value == value.Val)
                        .FirstOrDefault();
                        if (filterValue is null)
                        {
                            attributeFilter.Values.Add(new FilterValue()
                            {
                                Count = 1,
                                Value = value.Val
                            });

                            filterValue = attributeFilter.Values[attributeFilter.Values.Count - 1];
                        }
                        else
                        {
                            filterValue.Count++;
                        }
                    }
                }
            }

            sendingFilterDTO.AttributeSetFilters = sendingFilterDTO.AttributeSetFilters.OrderBy(asf => asf.AttributeSetName).ToList();
            foreach (var attributeSetFilter in sendingFilterDTO.AttributeSetFilters)
            {
                attributeSetFilter.AttributeFilters = attributeSetFilter.AttributeFilters.OrderBy(af => af.AttributeName).ToList();
                foreach (var attributeFilter in attributeSetFilter.AttributeFilters)
                {
                    attributeFilter.Values = attributeFilter.Values.OrderBy(v => v.Value).ToList();
                }
            }

            sendingFilterDTO.PriceFilter = new PriceFilter()
            {
                From = 0,
                To = 0
            };

            sendingFilterDTO.SortingType = SortingDTONames.Alphabetical;

            return sendingFilterDTO;
        }
        public FinalFilterSet GetFinalFilterSet(FilterSetDTO filterSetDTO)
        {
            FinalFilterSet finalFilterSet = new();
            finalFilterSet.PriceFilter = filterSetDTO.PriceFilter;
            finalFilterSet.SortingType = filterSetDTO.SortingType;

            filterSetDTO.AttributeSetFilters.ForEach(asf =>
            {
                asf.AttributeFilters.ForEach(af =>
                {
                    af.Values.ForEach(v =>
                    {
                        if (v.IsChecked)
                        {
                            finalFilterSet.FinalFilters.Add(new FinalFilter()
                            {
                                AttributeSetId = asf.AttributeSetId,
                                AttributeId = af.AttributeId,
                                Value = v.Value
                            });
                        }
                    });
                });
            });

            return finalFilterSet;
        }

        public List<Product> GetProducts(ECommerceDbContext db, FinalFilterSet finalFilterSet, int subCategoryId)
        {
            List<Product> productsList = new();
            var products = db.Products
                .Where(p => p.SubCategoryId == subCategoryId)
                .Include(p => p.Values)
                .ThenInclude(v => v.Attribute_AttributeSet);

            if (finalFilterSet.PriceFilter.From != 0 || finalFilterSet.PriceFilter.To != 0)
            {
                products.Where(p => p.Price >= finalFilterSet.PriceFilter.From && p.Price <= finalFilterSet.PriceFilter.To);
            }

            //int checkedCount = this.GetCheckedCount(filterSetDTO);
            if (finalFilterSet.FinalFilters.Count() != 0)
            {
                finalFilterSet.FinalFilters = finalFilterSet.FinalFilters
                    .OrderBy(ff => ff.AttributeSetId)
                    .ThenBy(ff => ff.AttributeId)
                    .ToList();

                List<bool> and = new(), or = new();
                foreach (var product in products)
                {
                    int prevAttrId = 0;
                    and = new();
                    foreach (var finalFilter in finalFilterSet.FinalFilters)
                    {   
                        if (finalFilter.AttributeId != prevAttrId && prevAttrId != 0)
                        {
                            and.Add(or.Any(boolean => boolean == true));
                            or = new();
                        }

                        foreach (var value in product.Values)
                        {
                            if (value.Attribute_AttributeSet.AttributeSetId == finalFilter.AttributeSetId
                                && value.Attribute_AttributeSet.AttributeId == finalFilter.AttributeId)
                            {
                                if (value.Val == finalFilter.Value)
                                {
                                    or.Add(true);
                                }
                                else
                                {
                                    or.Add(false);
                                }
                                break;
                            }
                        }
                        prevAttrId = finalFilter.AttributeId;
                    }
                    and.Add(or.Any(boolean => boolean == true));
                    or = new();
                    if (and.All(boolean => boolean == true) && and.Count() != 0) productsList.Add(product);
                }

                int kek = 0;
                /*foreach (var filter in finalFilterSet.FinalFilters)
                {
                    foreach (var product in products)
                    {
                        foreach (var value in product.Values)
                        {
                            if (value.Val == filter.Value
                                && value.Attribute_AttributeSet.AttributeSetId == filter.AttributeSetId
                                && value.Attribute_AttributeSet.AttributeId == filter.AttributeId)
                            {
                                productsList.Add(product);
                            }
                        }
                    }
                }*/
                /*foreach (var product in products)
                {
                    bool isFiltered = false;
                    foreach (var filter in finalFilterSet.FinalFilters)
                    {
                        foreach (var value in product.Values)
                        {
                            if (value.Attribute_AttributeSet.AttributeSetId == filter.AttributeSetId
                                && value.Attribute_AttributeSet.AttributeId == filter.AttributeId)
                            {
                                if (value.Val == filter.Value)
                                {
                                    isFiltered = true;                                    
                                }
                                else
                                {
                                    isFiltered = false;
                                }
                                break;
                            }
                        }

                        if (!isFiltered) break;
                    }

                    if (isFiltered)
                    {
                        productsList.Add(product);
                    }
                }*/
            }
            else
            {
                productsList = products.ToList();
            }

            if (finalFilterSet.SortingType == SortingDTONames.Alphabetical || finalFilterSet.SortingType == "")
            {
                productsList = productsList
                    .OrderBy(p => p.Name)
                    .ToList();
            }
            else if (finalFilterSet.SortingType == SortingDTONames.Ascending)
            {
                productsList = productsList
                    .OrderBy(p => p.Price)
                    .ToList();
            }
            else if (finalFilterSet.SortingType == SortingDTONames.Descending)
            {
                productsList = productsList
                    .OrderByDescending(p => p.Price)
                    .ToList();
            }

            return productsList;
        }

        public int GetCheckedCount(FilterSetDTO filterSetDTO)
        {
            int checkedCount = 0;
            foreach (var attributeSetFilter in filterSetDTO.AttributeSetFilters)
            {
                foreach (var attributeFilter in attributeSetFilter.AttributeFilters)
                {
                    foreach (var value in attributeFilter.Values)
                    {
                        if (value.IsChecked) checkedCount++;
                    }
                }
            }

            return checkedCount;
        }
    }
}

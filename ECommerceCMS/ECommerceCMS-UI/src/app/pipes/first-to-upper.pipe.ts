import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'firstToUpper'
})
export class FirstToUpperPipe implements PipeTransform {

  transform(value: string): string {
    let firstLetter = value.charAt(0).toUpperCase();
    let rest = value.slice(1);
    return firstLetter + rest;
  }

}

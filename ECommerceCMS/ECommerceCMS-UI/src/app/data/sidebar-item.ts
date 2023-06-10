import { SidebarSubItem } from "./sidebar-sub-item";

export class SidebarItem {
    title: string = '';
    iconSrc: string = '';
    link: string = '';
    subItems: Array<SidebarSubItem> = [];
}
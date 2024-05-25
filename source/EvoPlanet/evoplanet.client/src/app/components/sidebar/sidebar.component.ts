import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {
  @Input() isExpanded: boolean = false;
  @Output() toggleSideBar: EventEmitter<boolean> = new EventEmitter<boolean>();

  handleSidebarToggle = () => { this.toggleSideBar.emit(!this.isExpanded) };
}

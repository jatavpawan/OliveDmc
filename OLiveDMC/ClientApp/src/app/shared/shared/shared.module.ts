import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CKEditorModule } from 'ng2-ckeditor';
// import { SafeHtmlPipe } from 'src/app/pipe/safe-html.pipe';
import { NgxSpinnerModule } from "ngx-spinner";
import { EditorModule } from '@tinymce/tinymce-angular';
import { UiSwitchModule } from 'ngx-toggle-switch';
import { TooltipModule } from 'ng2-tooltip-directive';
import { SafeHtmlPipe } from 'src/app/pipe/safe-html.pipe';
import { OwlModule } from 'ngx-owl-carousel'; 
import {MatDialogModule} from '@angular/material/dialog';
// import { SelectModule } from 'ng2-select';
// import { NgSelectModule } from '@ng-select/ng-select';

@NgModule({
  declarations: [
    SafeHtmlPipe

  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    CKEditorModule,
    NgxSpinnerModule,
    EditorModule,
    UiSwitchModule,
    TooltipModule,
    OwlModule,
    MatDialogModule,
    // NgSelectModule
    // SelectModule,
  ],
  exports:[
    ReactiveFormsModule,
    FormsModule,
    CKEditorModule,
    NgxSpinnerModule,
    EditorModule,
    UiSwitchModule,
    TooltipModule,
    SafeHtmlPipe,
    OwlModule,
    MatDialogModule,
    // NgSelectModule
    // SelectModule,
  ]
})
export class SharedModule { }

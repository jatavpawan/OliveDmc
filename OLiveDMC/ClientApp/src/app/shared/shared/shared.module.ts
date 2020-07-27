import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CKEditorModule } from 'ng2-ckeditor';
// import { SafeHtmlPipe } from 'src/app/pipe/safe-html.pipe';
import { NgxSpinnerModule } from "ngx-spinner";
import { EditorModule } from '@tinymce/tinymce-angular';
import { UiSwitchModule } from 'ngx-toggle-switch';
import { TooltipModule } from 'ng2-tooltip-directive';


@NgModule({
  declarations: [
    // SafeHtmlPipe

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
  ],
  exports:[
    ReactiveFormsModule,
    FormsModule,
    CKEditorModule,
    NgxSpinnerModule,
    EditorModule,
    UiSwitchModule,
    TooltipModule,

  ]
})
export class SharedModule { }

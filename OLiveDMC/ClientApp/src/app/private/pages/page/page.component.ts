import { Component, OnInit } from '@angular/core';
import { CdkDragDrop, CdkDragStart, CdkDragEnd, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { BlogService } from 'src/app/providers/BlogService/blog.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { Status } from 'src/app/model/ResponseModel';
import Swal from 'sweetalert2'
import { environment } from 'src/environments/environment';


@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.css']
})
export class PageComponent implements OnInit {

  todofilterInput: string = "";
  donefilterInput: string = "";
  apiendpoint:string = environment.apiendpoint;

  // todo = [
  //   { id: 1, title: 'Pawn' },
	// 	{ id: 2, title: 'Rook' },
	// 	{ id: 3, title: 'Knight' },
	// 	{ id: 4, title: 'Bishop' },
		
  // ];

  // done = [
  //   { id: 5, title: 'Queen' },
	// 	{ id: 6, title: 'King' }
  // ];

  todo:Array<any> =[];
  done:Array<any> =[];
  blogs:Array<any> =[];
  blogPriorityList: Array<any> =[];
  newBlogs :Array<any> =[];
  newBlogsPriorityList : Array<any> =[];
  
  constructor( 
    private  blogService: BlogService, 
    private spinner: NgxSpinnerService,
    ) {
 }

  ngOnInit(): void {
    this.GetAllBlog();
   
  }



  GetAllBlog(){
    debugger;
    this.blogService.GetAllBlog().subscribe(resp=>{
      debugger;
      if(resp.status == Status.Success){
          this.blogs = resp.data;
          this.getBlogPriorityList();

          // this.todo =  this.blogs;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  drop(event: CdkDragDrop<string[]>) {
    // If current element has ".selected"
    if (event.item.element.nativeElement.classList.contains("selected")) {
      this.multiDrag.dropListDropped(event);
    }
    // If dont have ".selected" (normal case)
    else {
      if (event.previousContainer === event.container) {
        moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
      } else {
        transferArrayItem(event.previousContainer.data,
          event.container.data,
          event.previousIndex,
          event.currentIndex);
          this.todofilterInput = "";
          this.donefilterInput = "";
      }
    }
    debugger;
    console.log("this.todo", this.todo);
    console.log("this.done", this.done);
  }

  /* TWO OBJECTS */

  multiSelect = { // Put ".selected" on elements when clicking after longPress or Ctrl+Click
    // Initial Variables
    longPressTime: 500, // in ms unit
    verifyLongPress: 0,
    multiSelect: false,
    verifyDragStarted: false,
    ctrlMode: false,
    firstContainer: null as unknown as HTMLElement,

    selectDrag(el: HTMLElement) {
      debugger;
      while (!el.classList.contains("cdk-drag")) {
        el = el.parentElement as HTMLElement;
      }
      return el;
    },

    mouseDown(e: Event) {
      debugger;
      var target = this.selectDrag(e.target as HTMLElement);
      let ctrlKey = (<KeyboardEvent>e).ctrlKey;

      if (this.multiSelect) { // If multiSelect is enabled
        /* The responsibility for removing only the first ".selected" has to be with mouseDown and not with mouseUp.
        if not you can't add the first one */
        // Remove
        let allSelected = document.querySelectorAll(".selected").length;
        if (allSelected == 1 && target.classList.contains("selected") && (this.ctrlMode ? ctrlKey : true)) { // If only have one ".selected" and it was clicked
          target.classList.remove("selected");  // remove ".selected"
          this.multiSelect = false; // turns off multiSelect
        }
      }

      else { // If multiSelect is disabled
        // Do this
        let addSelected = () => {
          this.multiSelect = true; // enable multiSelect
          this.firstContainer = target.parentElement as HTMLElement; //saves the container of the first selected element
          target.classList.add("selected"); // and add ".selected" to the current element clicked
        }

        // If using CTRL
        if (ctrlKey) {
          this.ctrlMode = true;
          addSelected();
        };

        // If using longPress
        this.verifyLongPress = setTimeout(() => { // If there is a LongPress
          this.ctrlMode = false;
          addSelected();
        }, this.longPressTime); // after "longPressTime"(ms)
      }
    },

    mouseUp(e: Event) {
      debugger;
      clearTimeout(this.verifyLongPress); // cancel LongPress

      if (this.multiSelect) { // If multiSelect is enabled
        var target = this.selectDrag(e.target as HTMLElement);
        let allSelected = document.querySelectorAll(".selected");
        let ctrlKey = (<KeyboardEvent>e).ctrlKey;

        // If not start DragStarted
        if (!this.verifyDragStarted) {

          // To remove from selection
          /* responsibility to remove from selection assigned to mouseUp */
          if (target.classList.contains("selected")) { // If the clicked element already has ".selected"
            if (allSelected.length > 1 && (this.ctrlMode ? ctrlKey : true)) { // If you have more than 1 (not to remove the first one added)
              target.classList.remove("selected"); // remove ".selected"
            }
          }

          // To add to selection
          else { // if the clicked element does not have the ".selected"
            if (this.firstContainer == target.parentElement && (this.ctrlMode ? ctrlKey : true)) { //if the item click is made within the same container
              target.classList.add("selected"); // add ".selected"
            }
            else if (this.ctrlMode ? ctrlKey : true) { // if in different container, and with ctrl (if ctrl)
              allSelected.forEach((el) => { // remove all selected
                el.classList.remove("selected");
                el.classList.remove("hide");
              });
              this.firstContainer = target.parentElement as HTMLElement; //saves the container of the new selected element
              target.classList.add("selected"); // and add ".selected" to the element clicked
            }
          }

        }
      }
    },

    dragStarted() {
      // debugger;
      this.verifyDragStarted = true; // shows to mouseDown and mouseUp that Drag started
      clearTimeout(this.verifyLongPress); // cancel longPress
    },

    dragEnded() {
      this.verifyDragStarted = false; // show mouseDown and mouseUp that Drag is over
    },

    dropListDropped(e: CdkDragDrop<string[]>) {
      debugger;
      let el = e.item.element.nativeElement;
      if (el.classList.contains("selected")) { // the dragged element was of the "selected" class
        this.multiSelect = false; // disable multiSelect
      }
    },

  }


  multiDrag = { // Adjusts clicked items that have ".selected" to organize together
    // Initial Variables
    dragList: [""], // has the value of the selected items in sequence from listData
    dragListCopy: [""], // a copy of the listData, but with the selected elements marked with "DragErase" to delete later
    dragErase: Symbol("DragErase") as any, // a symbol to have unique value when deleting

    dragStarted(e: CdkDragStart) {
      // debugger;
      if (e.source.element.nativeElement.classList.contains("selected")) { // If the dragged element has ".selected"
        //prepare
        let listData = e.source.dropContainer.data; // get list data value
        this.dragList = []; // reset the dragList
        this.dragListCopy = [...listData]; // copy listData into variable
        let DOMdragEl: any = e.source.element.nativeElement; // dragged element
        let DOMcontainer = [...DOMdragEl.parentElement!.children]; // container where all draggable elements are
        let DOMdragElIndex = DOMcontainer.indexOf(DOMdragEl); // index of the dragged element
        let allSelected = document.querySelectorAll(".selected"); // get all the ".selected"

        // Goes through all ".selected"
        allSelected.forEach((eli) => {
          // get index of current element
          let CurrDOMelIndexi = DOMcontainer.indexOf(eli);

          // Add listData of current ".selected" to dragList
          this.dragList.push(listData[CurrDOMelIndexi]);

          // Replaces current position in dragListCopy with "DragErase" (to erase exact position later)
          this.dragListCopy[CurrDOMelIndexi] = this.dragErase;

          // Put opacity effect (by CSS class ".hide") on elements (after starting Drag)
          if (DOMdragElIndex !== CurrDOMelIndexi) {
            eli.classList.add("hide");
          }
        });

      }
    },

    dropListDropped(e: CdkDragDrop<string[]>) {
      debugger;
      if (e.previousContainer === e.container) { // If in the same container

        let posAdjust = e.previousIndex < e.currentIndex ? 1 : 0; // Adjusts the placement position
        this.dragListCopy.splice(e.currentIndex + posAdjust, 0, ...this.dragList); // put elements in dragListCopy
        this.dragListCopy = this.dragListCopy.filter((el) => (el !== this.dragErase)); // remove the "DragErase" from the list

        // Pass item by item to final list
        for (let i = 0; i < e.container.data.length; i++) {
          e.container.data[i] = this.dragListCopy[i];
        }
        this.todofilterInput = "";
        this.donefilterInput = "";
      }

      else { // If in different containers

        // remove the "DragErase" from the list
        this.dragListCopy = this.dragListCopy.filter((el) => (el !== this.dragErase));

        // Pass item by item to initial list
        for (let i = 0; i < e.previousContainer.data.length; i++) {
          e.previousContainer.data[i] = this.dragListCopy[i];
        }
        for (let i = 0; i < this.dragList.length; i++) {
          e.previousContainer.data.pop();
        }


        let otherListCopy = [...e.container.data]; // list of new container
        otherListCopy.splice(e.currentIndex, 0, ...this.dragList); // put elements in otherListCopy

        // Pass item by item to final list
        for (let i = 0; i < otherListCopy.length; i++) {
          e.container.data[i] = otherListCopy[i];
        }
        this.todofilterInput = "";
        this.donefilterInput = "";

      }

      // Remove ".selected" and ".hide"
      setTimeout(() => {
        let allSelected = document.querySelectorAll(".selected");
        allSelected.forEach((el) => {
          el.classList.remove("selected");
          el.classList.remove("hide");
        });
      }, 0)

      this.dragListCopy = []; // reset the dragListCopy
      this.dragList = []; // reset the dragList
    },

  }



  selectAllInTodoList() {
    debugger;
    var todolist = document.querySelectorAll('.todolist');

    todolist.forEach(item => {
      item.classList.add("selected");
    })
  }

  deSelectAllInTodoList() {
    debugger;
    var todolist = document.querySelectorAll('.todolist');

    todolist.forEach(item => {
      item.classList.remove("selected");
    })
  }

  
  selectAllInDoneList() {
    debugger;
    var donelist = document.querySelectorAll('.donelist');
    donelist.forEach( item => {
      item.classList.add("selected");
    })
  }

  deSelectAllInDoneList() {
    debugger;
    var donelist = document.querySelectorAll('.donelist');

    donelist.forEach(item => {
      item.classList.remove("selected");
    })
  }

  save(){
    debugger;
    let data: Array<any> = [];
    this.done.forEach(item =>{
        let blogobj = {
          BlogId : item.id 
        }
        data = [...data, blogobj];      
    })
    this.spinner.show();

    this.blogService.saveBlogPriority(data).subscribe(resp=>{
      debugger;
      this.spinner.hide();
      
      if(resp.status == Status.Success){
          debugger;  
          Swal.fire('', resp.message,'success');
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    

  }
  
  getBlogPriorityList(){
    debugger;
    this.blogService.getAllBlogPriorityList().subscribe(resp=>{
      if(resp.status == Status.Success){
          debugger;  
          this.blogPriorityList =  resp.data;
          if(this.blogPriorityList.length != 0){
              this.blogs.forEach(item => {
                if(this.blogPriorityList.findIndex(x => x.id == item.id ) != -1){
                   this.newBlogsPriorityList = [...this.newBlogsPriorityList, item]
                }
                else{
                   this.newBlogs  = [...this.newBlogs , item]
                } 
             })
             this.todo = this.newBlogs;
            //  this.done = this.newBlogsPriorityList;
             this.done = this.blogPriorityList;
          }
          else{
             this.newBlogs = this.blogs;
             this.newBlogsPriorityList = [];
             this.todo = this.newBlogs;
            //  this.done = this.newBlogsPriorityList;
             this.done = this.blogPriorityList;
          }



      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    

  }







}


 

import { Pipe, PipeTransform } from '@angular/core';


@Pipe({
  name: 'Role',
  pure:true
})
export class RolePipe implements PipeTransform {

  transform(value:number):string {
   
    if(value === 1){
      return 'regestered';
    }
    if(value === 2){
      return 'admin'
    }
    return 'guest';
  }

}

import { Pipe, PipeTransform } from '@angular/core';
import { Role } from '../models/role.enum';


@Pipe({
  name: 'Role',
  pure:true
})
export class RolePipe implements PipeTransform {

  transform(value:Role):string {
   
    if(value === Role.regestered){
      return 'regestered';
    }
    if(value === Role.admin){
      return 'admin'
    }
    return 'guest';
  }

}

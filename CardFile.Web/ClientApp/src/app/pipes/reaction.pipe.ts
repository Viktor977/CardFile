import { Pipe, PipeTransform } from '@angular/core';
import { Assessment } from '../models/assessment';


@Pipe({
  name: 'Reaction'
})
export class ReactionPipe implements PipeTransform {

  transform(value:Assessment): string{
    if(value===Assessment.Like){
      return ' LIKE!';
    }
    if(value===Assessment.Dislike){
      return ' DISLIKE!'
    }
    if(value===Assessment.Smile){
      return ' SMILE :) '
    }
    if(value===Assessment.Ugly){
      return ' Ugly :( '
    }
  }

}

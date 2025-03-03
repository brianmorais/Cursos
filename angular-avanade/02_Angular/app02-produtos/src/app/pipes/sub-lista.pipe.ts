import { Pipe, PipeTransform } from '@angular/core';
import { Produto } from '../classes/produto';

@Pipe({
  name: 'subLista'
})
export class SubListaPipe implements PipeTransform {
  transform(produtos: Produto[], input: string): Produto[] {
    if (!input)
      return produtos;

    return produtos.filter(produto =>
      produto.descricao.toLowerCase()
        .includes(input.toLowerCase()));
  }
}

import { Product } from './product';
export class CartItem {
  masach: string;
  ten_khiem: string;
  gia: number;
  quantity: number;
  constructor(product: Product) {
    this.masach = product.masach;
    this.ten_khiem = product.ten_khiem;
    this.gia = product.gia;

    this.quantity = 1;
  }
}

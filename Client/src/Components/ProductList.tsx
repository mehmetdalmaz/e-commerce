import { IProduct } from "../model/IProduct";
import Product from "./Product";

export default function ProductList(props: any) {

  
    return (
  
     <>
      <h1>ProductList</h1>
     {props.Products.map((p:IProduct) => (
      <Product key={p.id} Product={p} />
     ))}
  
     <button onClick={ props.addProduct }> add product</button>
  
     </>
  
  
  
    );
  }
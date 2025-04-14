import { useEffect, useState } from "react";
import { IProduct } from "../model/IProduct";
import Header from "./Header";
import ProductList from "./ProductList";


function App() {
  const [Products, setProduct] = useState<IProduct[]>([]);

    useEffect(() =>{
      fetch("http://localhost:5009/api/Product")
      .then(Response => Response.json())
      .then(data => setProduct(data))

    }, [])

   

  function addProduct() {
    setProduct([...Products,
          {
            id: Date.now(),
            name: "product4",
            price: 40000,
            isActive: true
          } 
          ])
  }

  return (
    <>
    <Header products={Products}/>
    <ProductList Products={Products} addProduct={addProduct} />
    </>
  )
}







export default App

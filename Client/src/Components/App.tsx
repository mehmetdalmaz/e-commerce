import { useEffect, useState } from "react";
import { IProduct } from "../model/IProduct";
import Header from "./Header";
import ProductList from "./ProductList";
import { Container, CssBaseline } from "@mui/material";


function App() {
  const [Products, setProduct] = useState<IProduct[]>([]);

    useEffect(() =>{
      fetch("http://localhost:5009/api/Product")
      .then(Response => Response.json())
      .then(data => setProduct(data))

    }, [])

   

  

  return (
    <>
    <CssBaseline/>
    <Header />
    <Container>
    <ProductList products={Products}  />
    </Container>
    
    </>
  )
}







export default App

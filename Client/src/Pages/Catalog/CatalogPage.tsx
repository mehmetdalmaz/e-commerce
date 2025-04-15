import { useEffect, useState } from "react";
import ProductList from "./ProductList"
import { IProduct } from "../../model/IProduct";
import { CircularProgress } from "@mui/material";

function CatalogPage() {

   const [Products, setProduct] = useState<IProduct[]>([]);
   const [loading, setLoading] = useState(true);


       useEffect(() =>{
      fetch("http://localhost:5009/api/Product")
      .then(Response => Response.json())
      .then(data => setProduct(data))
      .finally(()=> setLoading(false))

    }, [])
    if (loading) {
      return <CircularProgress/>
    }

  return (

    <ProductList products={Products}/>
   
  )
}

export default CatalogPage
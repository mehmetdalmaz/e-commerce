import { useEffect, useState } from "react";
import ProductList from "./ProductList"
import { IProduct } from "../../model/IProduct";
import { CircularProgress } from "@mui/material";
import request from "../../Api/Request";

function CatalogPage() {

   const [Products, setProduct] = useState<IProduct[]>([]);
   const [loading, setLoading] = useState(true);


       useEffect(() =>{
        request.Catalog.list()
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
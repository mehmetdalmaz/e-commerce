import { Card, CardMedia } from "@mui/material";
import { IProduct } from "../model/IProduct";

interface Props {
  product: IProduct
}

export default function Product({product}: Props) {
    return (
     
      <Card>
        <CardMedia image= {`http://localhost:5009/images/${product.imageUrl}`}/>
      </Card>
      
  
    );
  }
  
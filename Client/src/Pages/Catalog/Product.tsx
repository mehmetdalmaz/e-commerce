import { Button, Card, CardActions, CardContent, CardMedia, Typography } from "@mui/material";
import { IProduct } from "../../model/IProduct";
import { AddShoppingCart, Search } from "@mui/icons-material";
import { Link } from "react-router";
import { useState } from "react";
import request from "../../Api/Request";

interface Props {
  product: IProduct
}

export default function Product({product}: Props) {

  const [loading, setLoading] = useState(false);


  function handleAddItem(productId: number)
  {
    setLoading(true)

    request.Cart.addItem(productId)
    .then(cart => console.log(cart))
    .catch(error => console.log(error))
    .finally(()=> setLoading(false));



  }






    return (   
      <Card>
        <CardMedia sx={{height:160, backgroundSize:"contain"}} image= {`http://localhost:5009/images/${product.imageUrl}`}/>
        <CardContent>
          <Typography gutterBottom variant="h6" component="h2" color="text.secondary">
            {product.name}
          </Typography>
          <Typography variant="body2" color="secondary" >
            {(product.price/100).toFixed(2)} ₺
          </Typography>
        </CardContent>
        <CardActions>

          <Button
          variant="outlined"
          loading={loading}
          size="small" 
          startIcon={<AddShoppingCart/>} 
          onClick={()=> handleAddItem(product.id) } > Add to cart</Button>

          


          <Button component={Link} to={`/catalog/${product.id}`} variant="outlined" size="small" startIcon={<Search/>} color="primary"  > view</Button>

        </CardActions>
        
      </Card>
      
  
    );
  }
  
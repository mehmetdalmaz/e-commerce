import { CircularProgress,Button, Divider, Grid, Stack, TableBody, TableCell, TableContainer, TableRow, Typography } from "@mui/material"
import { useEffect, useState } from "react";
import { useParams } from "react-router"
import { IProduct } from "../../model/IProduct";
import request from "../../Api/Request";
import { AddShoppingCart } from "@mui/icons-material";
import { useCartContext } from "../../Context/CartContext";
import { toast } from "react-toastify";


function ProductDetails() {
  const {cart ,setCart} = useCartContext()

    const {id} = useParams<{id: string } >();
    const [product, setProduct] = useState< IProduct | null>(null);
    const [loading, setLoading] = useState(true);
    const [isAdded, setIsAdded] = useState(false);


    const item = cart?.cartItems.find(i=>i.productId===product?.id);
    useEffect(() => {
      id && request.Catalog.details(parseInt(id))
        .then(data => setProduct(data))
        .catch(error=> console.log(error))
        .finally(() => setLoading(false))
    },[id]);



    function handleAddItem (id: number) 
    {
      setIsAdded(true)
        request.Cart.addItem(id)
        .then(cart => {
          setCart(cart);
          toast.success("Sepetinize Eklendi")
          
        })
        .catch(error=> console.log(error))
        .finally(() => setIsAdded(false)) 
      
    }

    if (loading) {
        return <CircularProgress/>
    }
    if (!product) {
        return <h5>Product not found</h5>
    }



  return (
   <Grid container spacing={6}>
    <Grid size={{lg:4, md:5, sm:6, xs:12}}>
      <img src={`http://localhost:5009/images/${product.imageUrl}`} style={{width: "100%"}}/>
    </Grid >
    <Grid size={{lg:8, md:7, sm:6, xs:12}} >
    <Typography variant="h3">{product.name}</Typography>
    <Divider sx={{mb: 2}}/>
    <Typography variant="h4" color="secondary" >{(product.price/100).toFixed(2)} ₺</Typography>
    <TableContainer>
  <table style={{ width: "100%" }}>
    <TableBody>
      <TableRow>
        <TableCell>Name</TableCell>
        <TableCell>{product.name}</TableCell>
      </TableRow>

      <TableRow>
        <TableCell>Description</TableCell>
        <TableCell>{product.description}</TableCell>
      </TableRow>

      <TableRow>
        <TableCell>Stock</TableCell>
        <TableCell>{product.stock}</TableCell>
      </TableRow>
    </TableBody>
  </table>
</TableContainer>


    <Stack direction="row"spacing={3} sx={{mt:3}} alignItems={"center"} >
      <Button 
      variant= "outlined" 
      loadingPosition="start"
      startIcon={<AddShoppingCart/>}
      loading= {isAdded}
      onClick={() => handleAddItem(product.id)}
      > 
      Sepete Ekle

      </Button>

      {
        item?.quantity! > 0 && (
          <Typography  variant="body2">Sepetinize {item?.quantity} adet ürün eklendi</Typography>
        )
      }


    </Stack>
    </Grid>
   



    
    
   </Grid> 

  )
}

export default ProductDetails
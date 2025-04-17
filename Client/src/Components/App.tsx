import Header from "./Header";
import { CircularProgress, Container, CssBaseline } from "@mui/material";
import { useEffect, useState } from "react";
import { Outlet } from "react-router";
import request from "../Api/Request";
import { useCartContext } from "../Context/CartContext";
import { ToastContainer } from "react-toastify";


function App() {

const [loading, setLoading] = useState(true)
const {setCart} = useCartContext();



 useEffect(() => {
  request.Cart.get()
  .then(cart => setCart(cart))
  .catch(error=> console.log(error))
  .finally(()=> setLoading(false))

 }, []);

 if (loading) {
  return <CircularProgress/>
 }
   

  

  return (
    <>
    <ToastContainer position="bottom-right" hideProgressBar theme="colored"/>
    <CssBaseline/>
    <Header />
    <Container>
      <Outlet/>
    </Container>
    
    </>
  )
}







export default App

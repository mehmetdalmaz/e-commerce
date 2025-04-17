import { ShoppingCart } from "@mui/icons-material";
import { AppBar, Badge, Box, Button, IconButton, Stack, Toolbar, Typography } from "@mui/material";
import { Link, NavLink } from "react-router";
import { useCartContext } from "../Context/CartContext";

const links = [
  {title:"Home", to:"/"},
  {title:"Catalog", to:"/catalog"},
  {title:"About", to:"/about"},
  {title:"Contact", to:"/contact"}


]
const NavStyles = {
  color: "inherit",
  textdecoration:"none",
  "&:hover":{
    color: "text.primary"
  },
  "&.active":{
    color: "warning.main"
  }

}

export default function Header() {

  const { cart } = useCartContext();

  const itemCount = cart?.cartItems.reduce((total,item) => total + item.quantity,0)



    return (
  

      <AppBar position="static" sx={{mb: 4}}>
        <Toolbar sx={{display: "flex", justifyContent: "space-between"}}>


         <Box sx={{display:"flex", alignItems:"center"}}>
         <Typography variant="h6">E-Commerce</Typography>
          <Stack direction={"row"}>
            {links.map(link =>
              <Button key={link.to} component={NavLink} sx={NavStyles} to={link.to}>{link.title}</Button>
             )}
          </Stack>
         </Box>


         <Box>
          <IconButton component={Link} to="/cart"  size="large" edge= "start" color="inherit">
            <Badge badgeContent={itemCount} color= "secondary">
              <ShoppingCart/>
            </Badge>
          </IconButton>
         </Box>



        </Toolbar>
      </AppBar>
  

    );
  }
  
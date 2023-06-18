import { CardMedia, CardContent, Typography, CardActions, Button, Card, CardHeader, Avatar } from "@mui/material";
import { Link } from "react-router-dom";
import { Product } from "../../app/models/product";
import { LoadingButton } from "@mui/lab";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { addBasketItemAsync } from "../basket/basketSlice";

interface Props{
    product: Product;
}


export default function ProductCard({product}: Props) {

  const { status } = useAppSelector(state => state.basket);
  const dispatch = useAppDispatch();


  return (

  <Card sx={{bgcolor: '#ffffff'}}>
    <CardHeader sx={{bgcolor: '#ffffff'}}
      avatar={
        <Avatar sx={{bgcolor: "secondary.main"}}>
          {product.name.charAt(0).toUpperCase()}
        </Avatar>
      }
      title={product.name}
      titleTypographyProps={{
        sx: { fontWeight: 'bold', color: 'primary.main'}
      }}
    />

      <CardMedia
        sx={{ height: 140, backgroundSize: 'contain', bgcolor: '#ffffff' }}
        image={product.pictureUrl}
        title={product.name}
      />

      <CardContent>
        <Typography gutterBottom color='secondary' variant="h5">
          {(product.price)},99 RSD
        </Typography>

        <Typography variant="body2" color="#393939">
          {product.brand} / {product.type}
        </Typography>
      </CardContent>


      <CardActions>
        <LoadingButton 
        loading={status.includes('pendingAddItem' + product.id)} 
        onClick={() => dispatch(addBasketItemAsync({productId: product.id, quantity: 1}))}
        size="small">Dodaj u korpu</LoadingButton>
        <Button component={Link} to={`/catalog/${product.id}`} size="small">Pregled</Button>
      </CardActions>
  </Card>

    )
}

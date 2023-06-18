import { Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, TextField, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import NotFound from "../../app/errors/NotFound";
import { LoadingButton } from "@mui/lab";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { addBasketItemAsync, removeBasketItemAsync } from "../basket/basketSlice";
import { fetchProductAsync, productSelectors } from "./catalogSlice";
import LoadingComponent from "../../app/layout/LoadingComponent";

export default function ProductDetails() {
    // ok ovo je kul, kako da definises default vrednost
    const {id} = useParams<{id: string}>();
    const {basket, status} = useAppSelector(state => state.basket);
    const dispatch = useAppDispatch();

    const product = useAppSelector(state => productSelectors.selectById(state, id!));
    const {status: productStatus} = useAppSelector(state => state.catalog);
    const [quantity, setQuantity] = useState(1);
    const item = basket?.items.find(i => i.productId === product?.id);


    // kada se definise zavisnost onda ce se useEffect pozivati samo onda kada
    // se bude pribavljao id(kada se vrednost id-ja menja)
    useEffect(() => {
        if (item) setQuantity(item.quantity);
        if (!product && id!) dispatch(fetchProductAsync(parseInt(id)));
    }, [id, item, dispatch, product])

    function handleInputChange(event: any){
        if (event.target.value >=0) {
        setQuantity(parseInt(event.target.value));
        }
    }

    function findBasketItem(id: any): number {
        if (basket) {
            return basket.items.find((basketItem) => basketItem.productId === id)?.quantity ?? 0;
        }
        return 0;
    }

    //function handleUpdateCart() 
    //{
    //
    //if (!item || quantity > item.quantity) {
    //const updatedQuantity = item ? quantity - item.quantity : quantity;
    //dispatch(addBasketItemAsync({productId: product?.id!, quantity: updatedQuantity}))
    //} else {
    //const updatedQuantity = item.quantity - quantity;
    //dispatch(removeBasketItemAsync({productId: product?.id!, quantity:updatedQuantity}))
    //}
    //}

    function handleUpdateCart() {
        if (!item) {
            const updatedQuantity = quantity;
            dispatch(addBasketItemAsync({ productId: product?.id!, quantity: updatedQuantity }));
        } else if (quantity > item.quantity) {
            const updatedQuantity = quantity - item.quantity;
            dispatch(addBasketItemAsync({ productId: product?.id!, quantity: updatedQuantity }));
        } else if (quantity < item.quantity) {
            const updatedQuantity = item.quantity - quantity;
            dispatch(removeBasketItemAsync({ productId: product?.id!, quantity: updatedQuantity }));
        }
    }


    if (productStatus.includes('pending')) return <LoadingComponent message="Učitavam proizvode..."/>
    if (!product) return <NotFound />

    return (
        <Grid container spacing={6}>
            <Grid item xs={6}>
                <img src={product.pictureUrl} alt={product.name} style={{width:'100'}} />
            </Grid>
            <Grid item xs={6}>
                <Typography variant='h3'>{product.name}</Typography>
                <Divider sx={{mb:2}}/>
                <Typography variant='h4' color='secondary'>{(product.price).toFixed(0)},99 RSD</Typography>
                <TableContainer>
                    <Table>
                        <TableBody>
                            <TableRow>
                                <TableCell>Naziv</TableCell>
                                <TableCell>{product.name}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Opis proizvoda</TableCell>
                                <TableCell>{product.description}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Tip</TableCell>
                                <TableCell>{product.type}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Brend</TableCell>
                                <TableCell>{product.brand}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Količina u magacinu</TableCell>
                                <TableCell>{product.quantityInStock}</TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </TableContainer>

                <Grid container spacing={2}>

                    <Grid item xs={6}>
                        <TextField
                        onChange={handleInputChange}
                        variant='outlined'
                        type='number'
                        label='Količina u korpi'
                        fullWidth
                        value={quantity}
                        />
                    </Grid>

                    <Grid item xs={6}>
                            <LoadingButton
                            loading={status.includes('pending')}
                           disabled={!!(product?.quantityInStock && quantity + findBasketItem(item?.productId) > product.quantityInStock)}
                           onClick={handleUpdateCart}
                            sx={{height: '55px'}}
                            color="primary"
                            size="large"
                            variant="contained"
                            fullWidth
                            >
                                {item ? 'Ažuriraj količinu' : 'Dodaj u korpu'}
                            </LoadingButton>
                    </Grid>

                </Grid>
            </Grid>
        </Grid>
    )
}

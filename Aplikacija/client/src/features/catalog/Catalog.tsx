import ProductList from "./ProductList";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { setPageNumber, setProductParams } from "./catalogSlice";
import { FormGroup, Grid, Paper } from "@mui/material";
import ProductSearch from "./ProductSearch";
import RadioButtonGroup from "../../app/components/RadioButtonGroup";
import CheckboxButtons from "../../app/components/CheckboxButtons";
import AppPagination from "../../app/components/AppPagination";
import useProducts from "../../app/hooks/useProducts";

const sortOptions = [
  { value: 'name', label: 'Po nazivu' },
  { value: 'priceDesc', label: 'Cena - Viša ka nižoj' },
  { value: 'price', label: 'Cena - Niža ka višoj' },
] 

export default function Catalog() {
  const {products, brands, types, filtersLoaded, metaData} = useProducts();
  const { productParams } = useAppSelector(state => state.catalog);
  const dispatch = useAppDispatch();



  if (!filtersLoaded) return <LoadingComponent message="Učitavam proizvode..."/>
    
  return (
    
<Grid container columnSpacing={4}>
    <Grid item xs={3}>
          {/* PRETRAGA */}
          <Paper sx={{mb: 2}}>
            <ProductSearch />
          </Paper>

          {/* RADIO BUTTON SVRSTAVANJE */}
          <Paper sx={{mb: 2, p: 2}}>
            <RadioButtonGroup 
            selectedValue={productParams.orderBy}
            options={sortOptions}
            onChange={(e) => dispatch(setProductParams({orderBy: e.target.value}))}
            />
          </Paper>


          {/* PRETRAGA TIP */}
          <Paper sx={{mb: 2, p: 2}}>
            <CheckboxButtons 
            items={brands} 
            checked={productParams.brands}
            onChange={(items: string[]) => dispatch(setProductParams({brands: items}))}
            />
          </Paper>


          {/* PRETRAGA BREND */}
          <Paper sx={{mb: 2, p: 2}}>
            <FormGroup>
            <CheckboxButtons 
            items={types} 
            checked={productParams.types}
            onChange={(items: string[]) => dispatch(setProductParams({types: items}))}
            />
            </FormGroup>
          </Paper>
    </Grid>


        {/* PROIZVODI */}
        <Grid item xs={9}>
          <ProductList products={products} />
        </Grid>


        {/* STRANICENJE */}
        <Grid item xs={3}/>
          <Grid item xs={9}>
            {metaData &&
            <AppPagination 
            metaData={metaData}
            onPageChange={(page: number) => dispatch(setPageNumber({pageNumber: page}))}
            />}
          </Grid>
</Grid>
  )
}


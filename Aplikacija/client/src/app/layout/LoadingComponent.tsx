import { Backdrop, Box, CircularProgress, Typography } from "@mui/material";


interface Props{
    message?: string;
}
export default function LoadingComponent({message = 'Loading...'}: Props) {
    return (

         <Backdrop open={true} invisible={true} sx={{display:'flex', alignItems:'center', flexDirection:'column'}}>
            <Box sx={{display:'flex', alignItems:'center', flexDirection:'column'}} >
                <CircularProgress sx={{color:'danger', determinate:'false', size:'100', value:'39', varient:'solid'}} />
                <Typography variant="h5">{message}</Typography>
            </Box>
        </Backdrop> 
    )
}
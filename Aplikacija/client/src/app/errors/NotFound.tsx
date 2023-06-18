import { Button, Container, Divider, Paper, Typography } from "@mui/material";
import { Link } from "react-router-dom";

export default function ServerError() {

    return (
        <Container component={Paper} sx={{height: 'auto'}}>
             <Typography gutterBottom variant="h3">
                Nismo mogli da nadjemo šta ste tražili...
             </Typography>
             <Divider />
             <Button fullWidth component={Link} to ='/'>Hoćemo nazad na početnu?</Button>
        </Container>
    )
}
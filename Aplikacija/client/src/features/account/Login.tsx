import { LoadingButton } from '@mui/lab';
import { Avatar, Box, Container, Grid, Paper, TextField, Typography } from '@mui/material';
import { FieldValues, useForm } from 'react-hook-form';
import { Link, useLocation, useNavigate } from 'react-router-dom';
import { useAppDispatch } from '../../app/store/configureStore';
import { signInUser } from './accountSlice';
import FaceSharpIcon from '@mui/icons-material/FaceSharp';

export default function Login() {
  const navigate = useNavigate();
  const location = useLocation();
  const dispatch = useAppDispatch();
  const {register, handleSubmit, formState: {isSubmitting, errors, isValid}} = useForm({
      mode: 'onTouched'
  });  

  async function submitForm(data: FieldValues) {
    try {
        await dispatch(signInUser(data));
        navigate(location.state?.from || '/sve');
    } catch (error) {
        console.log(error);
    }
}

    return (
        <Container component={Paper} maxWidth='sm' sx={{ p: 4, display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
            <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                <FaceSharpIcon />
            </Avatar>
            <Typography component="h1" variant="h5">
                Prijavi se
            </Typography>
            <Box component="form" 
                onSubmit={handleSubmit(submitForm)} 
                noValidate sx={{ mt: 1 }}
            >
                <TextField
                    margin="normal"
                    required
                    fullWidth
                    label="Korisničko ime"
                    autoFocus
                    {...register('username', { required: 'Korisničko ime je obavezan parametar' })}
                    error={!!errors.username}
                    helperText={errors?.username?.message as string}
                />
                <TextField
                    margin="normal"
                    required
                    fullWidth
                    label="Lozinka"
                    type="password"
                    {...register('password', { 
                        required: 'Lozinka je obavezan parametar',
                        pattern: {
                            value: /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$/,
                            message: 'Lozinka ne upotpunjava potrebne parametre'
                        }
                    })}
                    error={!!errors.password}
                    helperText={errors?.password?.message as string}
                />
                <LoadingButton
                    disabled={!isValid}
                    loading={isSubmitting}
                    type="submit"
                    fullWidth
                    variant="contained" 
                    sx={{ mt: 3, mb: 2, bgcolor: 'secondary.main' }}
                >
                    Prijava
                </LoadingButton>
                <Grid container>
                    <Grid item>
                      <Link to='/register' style={{ textDecoration: 'none' }}>
                            {"Nemate nalog?"}
                        </Link>
                    </Grid>
                </Grid>
            </Box>
        </Container>
    );
}
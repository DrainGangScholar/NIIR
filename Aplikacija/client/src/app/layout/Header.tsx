import ShoppingBagTwoToneIcon from '@mui/icons-material/ShoppingBagTwoTone';
import { List, AppBar, ListItem, Switch, Toolbar, Typography, IconButton, Badge, Box } from "@mui/material";
import { Link, NavLink } from "react-router-dom";

import './logoTxt.css';
import { useAppSelector } from '../store/configureStore';
import SignedInMenu from './SignedInMenu';

const midlinks = [
    {title: 'katalog', path: '/sve'},
    {title: 'o nama', path: '/about'},
    {title: 'kontakt', path: '/contact'},
]

const rightlinks = [
    {title: 'prijava', path: '/login'},
    {title: 'registracija', path: '/register'},
]

const navStyles = {
        color: 'inherit', 
        textDecoration: 'none',
        typography: 'h6',
        '&:hover': {
            cursor: 'pointer',
            color: 'primary.dark',
          },
        '&.active':{
            color: 'primary.light'
        }
}

const InventoryButtonLink = {
    backgroundColor: '#6E21C9',
    color: '#FFFFFF',
    padding: '1 1 1 1',
    fontSize: '8px',
    cursor: 'pointer',
    transition: 'background-color 0.3s',
    typography: 'h6',
    '&:hover': {
      backgroundColor: '#f162ff',
    },
  
    '&:focus': {
      outline: 'none',
      boxShadow: '0 0 0 2px rgba(0, 90, 240, 0.5)',
    },
};
   

const navStylesLogo = {
    color: '#FFFFFF', 
    textDecoration: 'none',
    typography: 'h5',
};



interface Props {
    darkMode: boolean,
    handleThemeChange: () => void;
}

export default function Header({darkMode, handleThemeChange}: Props) {
    
    const {basket} = useAppSelector(state => state.basket);
    const itemCount = basket?.items.reduce((sum, item) => sum + item.quantity, 0 )
    const {user} = useAppSelector(state => state.account)



    return(
        <AppBar position='static' >
            <Toolbar sx={{display:'flex', justifyContent: 'space-between'}}>

                <Box display='flex' alignItems='center'>
                    <Typography 
                    variant='h6' 
                    component={NavLink} 
                    to='/'
                    sx={navStylesLogo} > 
                        <div className="logoTxt" style={{ fontFamily: 'Eurostile' }}>
                            NIIR
                        </div>
                    </Typography>
                    <Switch checked={darkMode} onChange={handleThemeChange}/> 
                </Box>

                <List sx={{ display: 'flex' }}>
                    {midlinks.map(({ title, path }) => (
                        <ListItem
                            component={NavLink}
                            to={path}
                            key={path}
                            sx={navStyles}
                        >
                            {title.toUpperCase()}
                        </ListItem>
                    ))} 
                    {user && user.roles?.includes('Admin') &&
                        <ListItem
                            component={NavLink}
                            to={'/inventory'}
                            sx={InventoryButtonLink}
                        >
                            INVENTAR
                        </ListItem>
                    }
                </List>



                <Box display='flex' align-items='center' sx={{ display: 'flex', alignItems: 'center' }}>
                        {/* IKONICA */}
                        <Box sx={{ display: 'flex', alignItems: 'center', borderRight: 2}}>
                    <IconButton component={Link} to='/basket' size='large' edge='start' color='inherit'>
                            <Typography >
                                KORPA
                            </Typography> 
                            <Badge badgeContent={itemCount} >
                                <ShoppingBagTwoToneIcon />
                            </Badge>
                    </IconButton>
                        </Box>
                    {user ? (
                        <SignedInMenu />
                    ) : (
                        <List sx={{ display: 'flex' }}>
                            {rightlinks.map(({ title, path }) => (
                                <ListItem
                                    component={NavLink}
                                    to={path}
                                    key={path}
                                    sx={navStyles}
                                >
                                    {title.toUpperCase()}
                                </ListItem>
                            ))}
                        </List>
                    )}
                </Box>
            </Toolbar>
        </AppBar>
    )
}
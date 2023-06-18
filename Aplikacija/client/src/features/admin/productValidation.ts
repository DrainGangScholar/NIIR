import * as yup from 'yup';

export const validationSchema = yup.object({
    name: yup.string().required("Ime artikla je obavezan paramtear"),
    brand: yup.string().required("Brend artikla je obavezan paramtear"),
    type: yup.string().required("Tip artikla je obavezan paramtear"),
    price: yup.number().required().moreThan(100),
    quantityInStock: yup.number().required().min(1),
    description: yup.string().required("Artikal mora da sadrzi opis"),
})

    
    
    
    

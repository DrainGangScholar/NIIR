import * as yup from 'yup';

export const validationSchema = [
    yup.object({
        fullName: yup.string().required('Puno ime je obavezan parametar'),
        address1: yup.string().required('Adresa 1 je obavezna primarna adresa'),
        address2: yup.string().required('Adresa 2 je obavezna sekundarna adresa'),
        city: yup.string().required('Grad je obavezan parametar'),
        zip: yup.string().required('Zip je obavezan parametar'),
        country: yup.string().required('Država je obavezan parametar'),
    }),
    yup.object(),
    yup.object({
        nameOnCard: yup.string().required('Ime nosioca kartice je obavezan parametar')
    })
]
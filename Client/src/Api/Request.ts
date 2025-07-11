import axios, { AxiosResponse } from "axios"

axios.defaults.baseURL="http://localhost:5009/api"
axios.defaults.withCredentials = true;

const queries = {
    get: (url:string) => axios.get(url).then((response: AxiosResponse ) => response.data) ,
    post: (url:string, body: {} ) => axios.post(url,body).then((response: AxiosResponse ) => response.data),
    put: (url:string, body: {} ) => axios.put(url, body).then((response: AxiosResponse ) => response.data),
    delete: (url:string) => axios.delete(url).then((response: AxiosResponse ) => response.data) 

}

const Catalog = {
    list: () => queries.get("Product"),
    details: (id: number)  => queries.get(`Product/${id}`)
}



const Cart = {
    get: () => queries.get("Cart"),
    addItem: (productId: number, quantity = 1) => queries.post(`Cart?productId=${productId}&quantity=${quantity}`,{}),
deleteItem:  (productId: number, quantity = 1) => queries.delete(`Cart?productId=${productId}&quantity=${quantity}`)

}
const request = {
    Catalog, Cart 
}

export default request

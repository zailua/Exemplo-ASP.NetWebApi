import axios from 'axios';

const Api = axios.create({ baseURL: 'https://localhost:7227/api' })

export default Api;
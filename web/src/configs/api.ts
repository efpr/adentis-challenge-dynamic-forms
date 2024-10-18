const API_HOST = import.meta.env.VITE_API_HOST || 'http://localhost:8080';


export default {
    company: {
        getAll: `${API_HOST}/companies`,
        getById: `${API_HOST}/companies/:id`,
    }
};
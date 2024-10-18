import axios from "axios";
import api from "../configs/api";
import { GetAllCompaniesResponse } from "../models/GetAllCompaniesResponse";
import { GetCompanyFormResponse } from "../models/GetCompanyFormResponse";


const GetAllCompanies = async (): Promise<GetAllCompaniesResponse[]> => {
    const response = await axios.get(api.company.getAll);
    return response.data;
};

const GetCompanyFormById = async (id: string): Promise<GetCompanyFormResponse> => {
    const requestPath = api.company.getById.replace(":id", id);
    const response = await axios.get(requestPath);
    return response.data;
};

export const CompanyAPI = {
    GetAllCompanies,
    GetCompanyFormById,
};

import { useEffect, useState } from "react";
import { GetAllCompaniesResponse } from "../models/GetAllCompaniesResponse";
import { CompanyAPI } from "../context/companyApi";
import Card from "react-bootstrap/esm/Card";
import Form from "react-bootstrap/esm/Form";
import Button from "react-bootstrap/esm/Button";
import { useNavigate } from "react-router-dom";

const getCompanyRoute = (id: string): string => {
    return "/company/" + id;
};

const Home = () => {
    const [companies, setCompanies] = useState<GetAllCompaniesResponse[]>([]);
    const [companyId, setCompanyId] = useState<string>("");

    const navigate = useNavigate();

    useEffect(() => {
        const fetchCompanies = async () => {
            const response = await CompanyAPI.GetAllCompanies();
            setCompanies(response);
            setCompanyId(response[0].id);
        };

        fetchCompanies();
    }, []);

    const onCompanyChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        setCompanyId(event.target.value);
    };

    const onCompanySelected = () => {
        const route = getCompanyRoute(companyId);
        navigate(route);
    };

    return (
        <div>
            <Card className="text-center">
                <Card.Body>
                    <Card.Title className="" style={{ userSelect: "none" }}>
                        Choose the company
                    </Card.Title>
                    <Form.Select
                        aria-label="Default select example"
                        className="mt-4"
                        onChange={onCompanyChange}
                    >
                        {companies.map((company) => (
                            <option key={company.id} value={company.id}>
                                {company.name}
                            </option>
                        ))}
                    </Form.Select>
                    <Button
                        variant="secondary"
                        className="mt-4"
                        onClick={onCompanySelected}
                    >
                        Submit
                    </Button>
                </Card.Body>
            </Card>
        </div>
    );
};

export default Home;

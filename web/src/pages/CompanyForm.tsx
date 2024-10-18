import { useEffect, useState } from "react";
import { CompanyAPI } from "../context/companyApi";
import { GetCompanyFormResponse } from "../models/GetCompanyFormResponse";
import { useNavigate, useParams } from "react-router-dom";
import Card from "react-bootstrap/esm/Card";
import Button from "react-bootstrap/esm/Button";
import CustomPlaceholder from "../components/placeholder";
import Stack from "react-bootstrap/esm/Stack";
import Form from "react-bootstrap/esm/Form";
import InputSelector from "../components/inputSelector";

const HOME_ROUTE = "/";

interface CompanyFormProps {
    showToast: () => void;
}

const CompanyForm = (props: CompanyFormProps) => {
    const [company, setCompany] = useState<GetCompanyFormResponse>();
    const { companyId } = useParams();

    const navigate = useNavigate();
    useEffect(() => {
        if (!companyId) {
            return;
        }

        const fetchCompany = async () => {
            const response = await CompanyAPI.GetCompanyFormById(companyId);
            setCompany(response);
        };

        fetchCompany();
    }, [companyId]);

    const onBackClicked = () => {
        navigate(HOME_ROUTE);
    };

    const onSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        props.showToast();

        navigate(HOME_ROUTE);
    }


    if (!company) {
        return <CustomPlaceholder />;
    }

    return (
        <Card style={{ width: "30em" }}>
            <Card.Header>
                <Stack direction="horizontal" gap={3}>
                    <div className="p-2">{company.name}</div>
                    <div className="p-2 ms-auto">
                        <Button variant="outline-danger" onClick={onBackClicked}>Back</Button>
                    </div>
                </Stack>
            </Card.Header>
            <Card.Body>
                <Form className="text-start" onSubmit={onSubmit}>
                    {company.formFields.map((field, idx) => (
                        <InputSelector
                            key={idx}
                            formField={field}
                            id={
                                "control." +
                                field.label.replace(" ", "") +
                                "." +
                                idx
                            }
                        />
                    ))}
                    <Stack gap={3} className="col-md-5 mx-auto">
                        <Button variant="primary" type="submit">
                            Submit
                        </Button>
                    </Stack>
                </Form>
            </Card.Body>
        </Card>
    );
};

export default CompanyForm;

import Form from "react-bootstrap/esm/Form";
import { FormField } from "../../models/GetCompanyFormResponse";

interface MultiselectProps {
    formField: FormField;
    id: string;
}

const MultiselectInput = (props: MultiselectProps) => {
    const getRequired = () => {
        const validation = props.formField.validation;
        if (!validation) {
            return false;
        }
        return validation.required;
    };

    if (!props.formField.options || props.formField.options.length === 0) {
        return <div>No options available</div>;
    }

    return (
        <Form.Select aria-label={props.formField.label} className="mb-3" multiple required={getRequired()}>
            {props.formField.options.map((option, index) => {
                return <option key={index} value={option}>{option}</option>
            })}
        </Form.Select>
    );
};

export default MultiselectInput;

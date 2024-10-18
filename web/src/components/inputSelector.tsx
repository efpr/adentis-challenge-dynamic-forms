import { FormField } from "../models/GetCompanyFormResponse";
import InputTextArea from "./inputTypes/InputDate";
import InputDate from "./inputTypes/InputDate";
import InputEmail from "./inputTypes/InputEmail";
import InputNumber from "./inputTypes/InputNumber";
import InputText from "./inputTypes/InputText";
import MultiselectInput from "./inputTypes/Multiselect";

interface InputSelectorProps {
    formField: FormField;
    id: string;
}

const InputSelector = (props: InputSelectorProps) => {
    switch (props.formField.type.toLocaleLowerCase()) {
        case "text":
            return <InputText formField={props.formField} id={props.id} />;
        case "email":
            return <InputEmail formField={props.formField} id={props.id} />;
        case "date":
            return <InputDate formField={props.formField} id={props.id} />;
        case "textarea":
            return <InputTextArea formField={props.formField} id={props.id} />;
        case "multiselect":
            return <MultiselectInput formField={props.formField} id={props.id} />;
        case "number":
            return <InputNumber formField={props.formField} id={props.id} />;
        default:
            return <></>;
    }
};

export default InputSelector;

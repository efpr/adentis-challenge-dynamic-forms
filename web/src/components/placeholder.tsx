import Card from "react-bootstrap/esm/Card";
import Placeholder from "react-bootstrap/Placeholder";

const CustomPlaceholder = () => {
    return (
        <Card style={{ width: "30em" }}>
            <Card.Body>
                <Placeholder as={Card.Title} animation="glow">
                    <Placeholder xs={6} />
                </Placeholder>
                <Placeholder as={Card.Text} animation="glow">
                    <Placeholder xs={7} /> <Placeholder xs={4} />{" "}
                    <Placeholder xs={4} /> <Placeholder xs={6} />{" "}
                    <Placeholder xs={8} />
                </Placeholder>
                <Placeholder as={Card.Text} animation="glow">
                    <Placeholder xs={7} /> <Placeholder xs={4} />{" "}
                    <Placeholder xs={4} /> <Placeholder xs={6} />{" "}
                    <Placeholder xs={8} />
                </Placeholder>
            </Card.Body>
        </Card>
    );
};

export default CustomPlaceholder;

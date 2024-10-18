import "./App.css";
import {
    BrowserRouter as Router,
    Route,
    Routes,
    Navigate,
} from "react-router-dom";
import Home from "./pages/Home";
import CompanyForm from "./pages/CompanyForm";
import Toast from "react-bootstrap/esm/Toast";
import { useState } from "react";

function App() {
    const [showToast, setShowToast] = useState(false);

    return (
        <Router>
            <div className="position-absolute top-0 end-0">
                <Toast className="d-inline-block m-1" bg={"success"} onClose={() => setShowToast(false)} show={showToast} delay={3000} autohide>
                    <Toast.Body>
                        Form submitted successfully
                    </Toast.Body>
                </Toast>
            </div>

            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/company/:companyId" element={<CompanyForm showToast={() => setShowToast(true)} />} />

                <Route path="*" element={<Navigate to="/" />} />
            </Routes>
        </Router>
    );
}

export default App;

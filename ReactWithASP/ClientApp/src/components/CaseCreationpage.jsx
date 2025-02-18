import React, { useState, useEffect } from "react";
import './Casecreationpage.css';

const CaseCreationpage = () => {
    const [categories, setCategories] = useState([]);
    const [reasons, setReasons] = useState([]);
    const [details, setDetails] = useState([]);
    const [clients, setClients] = useState([]);

    const [selectedcategory, setSelectedcategory] = useState("");
    const [selectedreason, setSelectedreason] = useState("");
    const [selecteddetail, setSelecteddetail] = useState("");
    const [selectedclient, setSelectedclient] = useState("");
    const [comments, setComments] = useState("");

    //Fetching category data
    useEffect(() => {
        fetch("/api/cases/categories") //Placeholder API call
            .then((res) => res.json())
            .then((data) => setCategories(data))
            .catch((err) => console.error("There has been an error in fetching categories :", err));
    }, []);

    //Fetching category data when its changed or updated
    useEffect(() => {
        if (selectedcategory) {
            fetch(`/api/cases/reasons/${selectedcategory}`)
                .then((res) => res.json())
                .then((data) => setReasons(data))
                .catch((err) => console.error("There has been an error in fetching reasons :", err));
        }
    }, [selectedcategory]);
    //Fetching reason data when its changed or updated
    useEffect(() => {
        if (selectedreason) {
            fetch(`api/cases/details/${selectedreason}`)
                .then((res) => res.json())
                .then((data) => setDetails(data))
                .catch((err) => console.error("There has been an error in fetching details :", err));
        }
    },[selectedreason]);
    useEffect(() => {
        fetch("/api/cases/clients")
            .then((res) => res.json())
            .then((data) => setClients(data))
            .catch((err) => console.error("There has been an error in fetching the client."));
    },[]);
    const handleSubmit = (e) => {
        e.preventDefault();
        console.log({
            selectedcategory,selectedreason,selecteddetail,selectedclient,comments
        });
        alert("Case submitted.");
    };

    return (
        <div className = "createcase-container">
            <h2 className = "createcase-title">CREATE CASE</h2>

            <form onSubmit={handleSubmit}>
                <div>
                    <label className="createcase-label">CATEGORY</label>
                    <select
                        className="createcase-select"
                        value={selectedcategory}
                        onChange={(e) => setSelectedcategory(e.target.value)}
                    >
                        <option value="">Select Category</option>
                        {categories.map((cat) => (
                            <option key={cat.categoryId} value={cat.categoryId}>
                                {cat.categoryName}
                            </option>
                        ))}
                    </select>
                </div>

                <div>
                    <label className="createcase-label">REASON</label>
                    <select
                        className="createcase-select"
                        value={selectedreason}
                        onChange={(e) => setSelectedreason(e.target.value)}
                        disabled={!selectedcategory}
                    >
                        <option value="">Select Reason</option>
                        {reasons.map((reason) => (
                            <option key={reason.reasonId} value={reason.reasonId}>
                                {reason.reasonName}
                            </option>
                        ))}
                    </select>
                </div>
                <div>
                    <label className="createcase-label">DETAIL</label>
                    <select
                        className="createcase-select"
                        value={selecteddetail}
                        onChange={(e) => setSelecteddetail(e.target.value)}
                        disabled={!selectedreason}
                    >
                        <option value="">Select Detail</option>
                        {details.map((detail) => (
                            <option key={detail.detailId} value={detail.detailId}>
                                {detail.detailName}
                            </option>
                        ))}
                    </select>
                </div>
                <div>
                    <label className="createcase-label" >COMMENTS</label>
                    <textarea
                        className="createcase-text"
                        rows="1"
                        value={comments}
                        onChange={(e) => setComments(e.target.value)}
                        placeholder="Enter comments..."
                    />
                </div>

                <div>
                    <label className="createcase-label">CLIENT</label>
                    <select className="createcase-select" value={selectedclient} onChange={(e) => setSelectedclient(e.target.value)}>
                        <option value="">Select Client</option>
                        {clients.map((client) => (
                            <option key={client.clientId} value={client.clientId}>
                                {client.clientName}
                            </option>
                        ))}
                    </select>
                </div>
                <button type="submit" className="createcase-btn">
                    Create Case
                </button>
            </form>
            </div>
    );
};

export default CaseCreationpage;
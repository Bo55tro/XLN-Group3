import React, { useState, useEffect } from "react";
import './Casecreationpage.css';


const CaseCreationpage = () => {
    const [categories, setCategories] = useState([]);
    const [reasons, setReasons] = useState([]);
    const [details, setDetails] = useState([]);
    const [clients, setClients] = useState([]);

    const [selectedCategory, setSelectedCategory] = useState("");
    const [selectedReason, setSelectedReason] = useState("");
    const [selectedDetail, setSelectedDetail] = useState("");
    const [selectedClient, setSelectedClient] = useState("");
    const [comments, setComments] = useState("");

    useEffect(() => {
        fetch("https://localhost:7192/api/cases/categories", { 
            method: "GET", 
            headers: { "Accept": "application/json" } // ✅ Remove unnecessary headers
        })
        .then((res) => {
            console.log("Response headers:", res.headers); // Debugging
            return res.json();
        })
        .then((data) => {
            console.log("Fetched categories:", data); // Debugging
            setCategories(data);
        })
        .catch((err) => console.error("Error fetching categories:", err));
    }, []);
    
    useEffect(() => {
        console.log("Selected Category:", selectedCategory);  // Debugging
    }, [selectedCategory]);
    
    
    // Fetch Reasons when Category is Selected
    useEffect(() => {
        setSelectedReason("");
        setReasons([]); 
        if (selectedCategory) {
            fetch(`https://localhost:7192/api/cases/reasons/${selectedCategory}`, {
                method: "GET",
                headers: { "Accept": "application/json" }
            })
            .then((res) => res.json())
            .then((data) => {
                console.log("Fetched reasons:", data);
                setReasons(data);
            })
            .catch((err) => console.error("Error fetching reasons:", err));
        }
    }, [selectedCategory]);

    // Fetch Details when Reason is Selected
    useEffect(() => {
        if (selectedReason) {
            fetch(`https://localhost:7192/api/cases/details/${selectedReason}`, {
                method: "GET",
                headers: { "Accept": "application/json" }
            })
            .then((res) => res.json())
            .then((data) => {
                console.log("Fetched details:", data); // Debugging
                setDetails(data);
            })
            .catch((err) => console.error("Error fetching details:", err));
        }
    }, [selectedReason]);


    useEffect(() => {
        fetch("https://localhost:7192/api/cases/clients") // ✅ Corrected to "clients"
            .then((res) => res.json())
            .then((data) => setClients(data))
            .catch((err) => console.error("Error fetching clients:", err));
    }, []);
    useEffect(() => {
        setSelectedReason("");  // Reset reason when category changes
        setReasons([]);  // Clear old reasons
    }, [selectedCategory]);
    
    useEffect(() => {
        setSelectedDetail("");  // Reset detail when reason changes
        setDetails([]);  // Clear old details
    }, [selectedReason]);
    const handleSubmit = (e) => {
        e.preventDefault();
        console.log({
            selectedCategory,selectedReason,selectedDetail,selectedClient,comments
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
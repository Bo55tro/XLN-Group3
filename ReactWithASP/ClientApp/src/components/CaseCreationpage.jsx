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
            headers: { "Accept": "application/json" }
        })
        .then((res) => {
            console.log("Response headers:", res.headers);
            return res.json();
        })
        .then((data) => {
            console.log("Fetched categories:", data);
            setCategories(data);
        })
        .catch((err) => console.error("Error fetching categories:", err));
    }, []);
    
    useEffect(() => {
        console.log("Selected Category:", selectedCategory);
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
                console.log("Fetched details:", data);
                setDetails(data);
            })
            .catch((err) => console.error("Error fetching details:", err));
        }
    }, [selectedReason]);


    useEffect(() => {
        fetch("https://localhost:7192/api/cases/clients")
            .then((res) => res.json())
            .then((data) => setClients(data))
            .catch((err) => console.error("Error fetching clients:", err));
    }, []);
    useEffect(() => {
        setSelectedReason("");
        setReasons([]);
    }, [selectedCategory]);
    
    useEffect(() => {
        setSelectedDetail("");
        setDetails([]);
    }, [selectedReason]);

    // Submit the form
    const handleSubmit = async (e) => {
        e.preventDefault();
    
        if (!selectedCategory || !selectedReason || !selectedDetail || !selectedClient) {
            alert("Please select all fields before submitting.");
            return;
        }
    
        const today = new Date();
        const formattedDate = today.toISOString().substring(0, 10); // Extracts YYYY-MM-DD

    
        const caseData = {
            categoryId: parseInt(selectedCategory),
            reasonId: parseInt(selectedReason),
            detailId: parseInt(selectedDetail),
            clientId: parseInt(selectedClient),
            caseComments: comments || "No comments provided",
            caseNotes: "Notes from Manager...",
            caseDate: formattedDate,
            caseStatus: "Open",
            agentId: 1 // Hardcoded for now
        };
    
        console.log("Submitting case:", JSON.stringify(caseData, null, 2));
    
        try {
            const response = await fetch("https://localhost:7192/api/cases/create", {
                method: "POST",
                headers: { 
                    "Accept": "application/json",
                    "Content-Type": "application/json" 
                },
                body: JSON.stringify(caseData),
            });
    
            if (!response.ok) {
                const errorText = await response.text();
                console.error("Server Response:", errorText);
    
                if (response.status === 400) {
                    alert("Validation Error: " + JSON.parse(errorText).message);
                } else if (response.status === 409) {
                    alert("Duplicate Case Found! Check similar cases.");
                } else {
                    alert("Unexpected Error. Check console for details.");
                }
    
                throw new Error(`HTTP error! Status: ${response.status}, Message: ${errorText}`);
            }
    
            const data = await response.json();
            console.log("Case created successfully:", data);
            alert("Case successfully created!");
    
            // ✅ Reset the form
            setSelectedCategory("");
            setSelectedReason("");
            setSelectedDetail("");
            setSelectedClient("");
            setComments("");
    
        } catch (error) {
            console.error("Error submitting case:", error);
            alert("Failed to create case. Check console for details.");
        }
    };
    
    
    

    return (
        <div className = "createcase-container">
            <h2 className = "createcase-title">Create a Case</h2>
            <h4 className = "createcase-subtitle">Please fill out the information below</h4>

            <form onSubmit={handleSubmit}>

                <div className = "createcase-dropdown-container"> 
                    <div className = "createcase-dropdown-wrapper"> 
                        <label className="createcase-label">Category</label>
                        <select
                            className="createcase-dropdown-box"
                            value={selectedCategory}
                            onChange={(e) => setSelectedCategory(e.target.value)}
                        >
                            <option value="">Select Category</option>
                            {categories.map((cat) => (
                                <option key={cat.categoryId} value={cat.categoryId}>
                                    {cat.categoryName}
                                </option>
                            ))}
                        </select>
                    </div>

                    <div className = "createcase-dropdown-wrapper">
                        <label className="createcase-label">Reason</label>
                        <select
                            className="createcase-dropdown-box"
                            value={selectedReason}
                            onChange={(e) => setSelectedReason(e.target.value)}
                            disabled={!selectedCategory}
                        >
                            <option value="">Select Reason</option>
                            {reasons.map((reason) => (
                                <option key={reason.reasonId} value={reason.reasonId}>
                                    {reason.reasonName}
                                </option>
                            ))}
                        </select>
                    </div>

                    <div className = "createcase-dropdown-wrapper"> 
                        <label className="createcase-label">Detail</label>
                        <select
                        className="createcase-dropdown-box"
                        value={selectedDetail}
                        onChange={(e) => setSelectedDetail(e.target.value)}
                        disabled={!selectedReason}
                    >
                        <option value="">Select Detail</option>
                        {details.map((detail) => (
                            <option key={detail.detailId} value={detail.detailId}>
                                {detail.detailName}
                            </option>
                        ))}
                    </select>
                    </div>
                </div>
                
                <div>
                    <label className="createcase-label" >Comments</label>
                    <textarea
                        className="createcase-comments"
                        rows="1"
                        value={comments}
                        onChange={(e) => setComments(e.target.value)}
                        placeholder="Enter comments..."
                    />
                </div>

                <div className="createcase-lastrow">
                    <div className="createcase-client">
                    <label className="createcase-label">Client</label>
                        <select className="createcase-select" value={selectedClient} onChange={(e) => setSelectedClient(e.target.value)}>
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
                </div>
            </form>
        </div>
    );
};

export default CaseCreationpage;
import React, { useState, useEffect } from "react";

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
        <div className="max-w-lg mx-auto p-6 bg-white shadow-lg rounded-lg">
            <h2 className="text-xl font-bold mb-4">Create Case</h2>

            <form onSubmit={handleSubmit} className="space-y-4">
                {/* Category Dropdown */}
                <div>
                    <label className="block text-sm font-medium">Category</label>
                    <select
                        className="w-full p-2 border rounded"
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

                {/* Reason Dropdown */}
                <div>
                    <label className="block text-sm font-medium">Reason</label>
                    <select
                        className="w-full p-2 border rounded"
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

                {/* Detail Dropdown */}
                <div>
                    <label className="block text-sm font-medium">Detail</label>
                    <select
                        className="w-full p-2 border rounded"
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

                {/* Comments Textbox */}
                <div>
                    <label className="block text-sm font-medium">Comments</label>
                    <textarea
                        className="w-full p-2 border rounded"
                        rows="3"
                        value={comments}
                        onChange={(e) => setComments(e.target.value)}
                        placeholder="Enter comments..."
                    />
                </div>

                {/* Clients Dropdown */}
                <div>
                    <label className="block text-sm font-medium">Client</label>
                    <select
                        className="w-full p-2 border rounded"
                        value={selectedClient}
                        onChange={(e) => setSelectedClient(e.target.value)}
                    >
                        <option value="">Select Client</option>
                        {clients.map((client) => (
                            <option key={client.clientId} value={client.clientId}>
                                {client.clientName}
                            </option>
                        ))}
                    </select>
                </div>

                {/* Submit Button */}
                <button
                    type="submit"
                    className="w-full bg-blue-600 text-white p-2 rounded hover:bg-blue-700"
                >
                    Create Case
                </button>
            </form>
        </div>
    );
};

export default CaseCreationpage;
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

    //Fetching category data
    useEffect(() => {
        fetch("/api/cases/categories") //Placeholder API call
            .then((res) => res.json())
            .then((data) => setCategories(data))
            .catch((err) => console.error("There has been an error in fetching categories :", err));
    }, []);

    //Fetching category data when its changed or updated
    useEffect(() => {
        if (selectedCategory) {
            fetch(`/api/cases/reasons/${selectedCategory}`)
                .then((res) => res.json())
                .then((data) => setReasons(data))
                .catch((err) => console.error("There has been an error in fetching reasons :", err));
        }
    }, [selectedCategory]);
    //Fetching reason data when its changed or updated
    useEffect(() => {
        if (selectedReason) {
            fetch(`/api/cases/details/${selectedReason}`)
                .then((res) => res.json())
                .then((data) => setDetails(data))
                .catch((err) => console.error("There has been an error in fetching details :", err));
        }
    },[selectedReason]);
    useEffect(() => {
        fetch("/api/cases/clients")
            .then((res) => res.json())
            .then((data) => setClients(data))
            .catch((err) => console.error("There has been an error in fetching the client."));
    },[]);
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
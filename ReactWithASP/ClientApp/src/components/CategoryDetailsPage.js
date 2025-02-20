import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import styles from "./Home.module.css";
const CategoryDetailsPage = () => {
    const { categoryId } = useParams();
    const [ category, setCategory ] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    useEffect(() => {
        fetch(`http://localhost:7192/api/categories/${categoryId}`)
            .then((response) => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                return response.json();
            })
            .then((data) => {
                setCategory(data);
                setLoading(false);
            })
            .catch((err) => {
                console.error("Error in fetching category details: ", err);
                setError('Unable to fetch category details');
                setLoading(false);
            });
    }, [categoryId]);
    if (loading) return <p>Loading category details..........</p>
    if (error) return <p>Error: {error}</p>
    return (
        <div>
            <h1>{category.categoryName}</h1>
            <p>Case Count: {category.caseCount}
                Details on {category.caseCount} will be displayed here.
            </p>
        </div>
    );
};
export default CategoryDetailsPage;
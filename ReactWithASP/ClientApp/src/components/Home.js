 
import React, {useState, useEffect } from 'react';
import {Link} from 'react-router-dom'
import styles from "./Home.module.css";

const CategoriesGrid = () => {
    const [categories, setCategories] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [searchTerm, setSearchTerm] = useState("");
    useEffect(() => {
        fetch('https://localhost:7192/api/cases/categories')
            .then((response) => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                return response.json();
            })
            .then((data) => {
                console.log("Fetched Categories Data:", data);
                setCategories(data);
                setLoading(false);
            })
            .catch((err) => {
                console.error("Found error in fetching the categories :", err);
                setError('Unable to fetch categories. Please try again later.');
                setLoading(false);
            });
    }, []);

 

    const filteredCategories = categories.filter(
        (category) => category.categoryName.toLowerCase().includes(searchTerm.toLowerCase())
    );

    if (loading)
        return <p>Loading categories......</p>;
    if (error) return <p>{error}</p>

    console.log("Search Term:", searchTerm);
    console.log("Categories:", categories);

   
    return (
            <div className={styles.dashboardContainer}>
            <div className={styles.searchBar}>
                <input
                    type="text" placeholder="Search categories..."
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                    className={styles.searchInput}
                />
                <button className={styles.searchButton} onClick={() => setSearchTerm("")}>
                    Clear
                </button>

            </div>
            <h2>Categories</h2>
            <div className={styles.gridContainer}>
                {filteredCategories.map((category) => (
                    <Link
                        key={category.categoryId}
                        to={`/category/${category.categoryId}`}
                        className={styles.categoryBox}>
                        <div>
                            <img
                                src={`${process.env.PUBLIC_URL}/images/${(category.categoryName|| "default").toLowerCase()}.jpg`}
                                onError={(e) => (e.target.src = `${process.env.PUBLIC_URL}/images/default.jpg`)}
                                alt={category.categoryName}
                            />
                        </div>
                        <div>
                            <h3>{category.categoryName}</h3>
                            <p>{category.caseCount} Cases</p>
                        </div>
                     </Link>

                ))}
            </div>
        </div>

    );
};
const Home = () => {
    return (
        <div className={styles.container}>
            <h1 className={styles.title}>Welcome to Daisy Project</h1>
            <CategoriesGrid />
        </div>
    );
};

export { Home };
export default Home;

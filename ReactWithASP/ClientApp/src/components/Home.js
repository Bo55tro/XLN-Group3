import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import styles from "./Home.module.css";

const CategoriesGrid = () => {
    const [categories, setCategories] = useState([]);
    const [searchTerm, setSearchTerm] = useState("");

    useEffect(() => {
      fetch('https://localhost:7192/api/categories/categorieswithCaseCount')
            .then((response) => response.json())
            .then((data) => setCategories(data))
            .catch((err) => console.error("Error fetching categories:", err));
    }, []);

    const filteredCategories = categories.filter(
        (category) => category.categoryName.toLowerCase().includes(searchTerm.toLowerCase())
    );

    return (
        <div className={styles.dashboardContainer}>
            <div className={styles.searchBar}>
                <input
                    type="text"
                    placeholder="Search cases..."
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                    className={styles.searchInput}
                />
            </div>

            <div className={styles.gridContainer}>
                {filteredCategories.map((category, index) => (
                    <Link key={category.categoryId} to={`/category/${category.categoryId}`} className={styles.categoryBox}>
                        <div className={styles.imageContainer}>
                        <img
                            src={`/Images/${category.categoryImage}`}
                            alt={category.categoryName}
                            onError={(e) => (e.target.src = "/Images/default.jpg")} // Fallback image
                        />
                        </div>
                        <div className={styles.categoryInfo}>
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

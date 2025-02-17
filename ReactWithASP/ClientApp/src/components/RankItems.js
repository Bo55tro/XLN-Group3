import React, { useState, useEffect } from 'react';

const RankItems = () => {
    const [items, setItems] = useState([]);

    useEffect(() => {
        fetch(`item/${dataType}`)
            .then((results) => {

            })

    }, []);
    return (
        <main>
            (items != null)?<div>

            </div>
        </main>

    )
}
// src/components/Products.js
import React, { useEffect, useState } from 'react';
import { Table, Spin } from 'antd';
import axios from 'axios';
const xhr = new XMLHttpRequest();

// xhr.open(
//     "GET",
//     "http://localhost:7281/Product/ProductsView",
//     true
// );
// xhr.setRequestHeader('Authorization', await firebase)

const Products = () => {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    
    useEffect(() => {
        fetchProducts();
    }, []);
    
    const fetchProducts = async () => {
        let array = []
        

        let config = {
            method: 'get',
            maxBodyLength: Infinity,
            url: 'http://localhost:7281/Product/ProductsView',
        };
        await axios.request(config)
        .then((response) => {

            // response.data.itens.forEach((element) => {
            //     if(element['standardCost'] = 1000) {
            //         array.push(element)
            //     }
            // })

            setProducts(response.data.itens)
            setLoading(false)
            console.log(response.data.itens)
        })
        .catch((error) => {
            console.log(error)
        })
    };
    
    const columns = [
        {
            title: 'Product ID',
            dataIndex: 'productID',
        },
        {
            title: 'Name',
            dataIndex: 'name',
        },
        {
            title: 'Product Number',
            dataIndex: 'productNumber',
        },
        {
            title: 'R$ Standard Cost',
            dataIndex: 'standardCost',
            render: (text) => {
                
                if (text > 1000) {
                    return <div style={{ color: 'green' }}>R$ {text}</div>
                }
                
                return <div style={{ color: 'red' }}>R$ {text}</div>;
            }
        },

        {
            title: 'List Price',
            dataIndex: 'listPrice',
            render: (text,) => {
               
                
                if (text > 1000) {
                    return <div style={{ color: 'green' }}>R$ {text}</div>
                }
                
                return `R$ ${text}`, <div style={{ color: 'red' }}>R$ {text}</div>;
            }
        },
        
       {
            title: 'porcentagem de lucro',
            render: (text, uva) => {
                const total = uva.listPrice / uva.standardCost;
                const formattedTotal = (total * 1).toFixed(2).replace(',', '.');
                const textToShow = `% ${formattedTotal}`;
                if (total > 2) {
                return <div style={{ color: 'green' }}>R$ {textToShow}</div>;
                }
                return <div style={{ color: 'red' }}>R$ {textToShow}</div>;
            }
        },

        
        {
            title: 'Subcategory',
            dataIndex: 'subcategory',
        },
        {
            title: 'Category',
            dataIndex: 'category',
        },
        {
            title: 'Model',
            dataIndex: 'model',
        },
        
    ];
    
    
    return (
        <div>
        {loading ? (
            <Spin />
            ) : (
                <Table dataSource={products} columns={columns}/>
                )}
                </div>
                );
            };
            
            export default Products;
            
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
        
        let config = {
            method: 'get',
            maxBodyLength: Infinity,
            url: 'http://localhost:7281/Product/ProductsView',
        };
        
        await axios.request(config)
        .then((response) => {
            setProducts(response.data.itens)
            console.log(response.data.itens)
            setLoading(false)
            // console.log(JSON.stringify(response.data))
        })
        .catch((error) => {
            console.log(error)
        })
        
        // try {  
        //   setProducts(response.data.itens);
        //   setLoading(false);
        // } catch (error) {
        //   console.error('Error fetching products:', error);
        //   setLoading(false);
        // }
    };
    
    const columns = [
        {
            title: 'Product ID',
            dataIndex: 'productID',
            key: 'productID',
        },
        {
            title: 'Name',
            dataIndex: 'name',
            key: 'name',
        },
        {
            title: 'Product Number',
            dataIndex: 'productNumber',
            key: 'productNumber',
        },
        {
            title: 'R$ Standard Cost',
            dataIndex: 'standardCost',
            key: 'StandardCost',
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
            key: 'listPrice',
            render: (text,) => {
               
                
                if (text > 1000) {
                    return <div style={{ color: 'green' }}>R$ {text}</div>
                }
                
                return <div style={{ color: 'red' }}>R$ {text}</div>;
            }
        },
        
        {
            title: 'porcentragem de lucro',
            key: 'listPrice',
            render: (abacte, uva) => {
                return `% ${uva.listPrice - uva.standardCost}`
            }
        },
        
        {
            title: 'Subcategory',
            dataIndex: 'subcategory',
            key: 'subcategory',
        },
        {
            title: 'Category',
            dataIndex: 'category',
            key: 'category',
        },
        {
            title: 'Model',
            dataIndex: 'model',
            key: 'model',
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
            
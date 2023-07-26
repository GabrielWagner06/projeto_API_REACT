import React, { useState } from 'react';
// import { Form, Input, Button } from 'antd';
import axios from 'axios';

const Login = () => {
  const [loading, setLoading] = useState(false);

  const onFinish = async (values) => {
    setLoading(true);
    try {
      const response = await axios.post('URL_DA_API/login', {
        username: values.username,
        password: values.password,
      });
      console.log('Login successful:', response.data);
      // Lógica para lidar com a resposta da API e redirecionar o usuário para a página apropriada
    } catch (error) {
      console.error('Login failed:', error);
      // Lógica para lidar com falha de autenticação, exibir mensagens de erro, etc.
    }
    setLoading(false);
  };

  return (
    <Form name="login" onFinish={onFinish}>
      <Form.Item
        label="Username"
        name="username"
        rules={[{ required: true, message: 'Please input your username!' }]}
      >
        <Input />
      </Form.Item>

      <Form.Item
        label="Password"
        name="password"
        rules={[{ required: true, message: 'Please input your password!' }]}
      >
        <Input.Password />
      </Form.Item>

      <Form.Item>
        <Button type="primary" htmlType="submit" loading={loading}>
          Log in
        </Button>
      </Form.Item>
    </Form>
  );
  
};

export default Login;

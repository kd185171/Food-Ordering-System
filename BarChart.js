import "./Dashboard.css";
import React from "react";
import {
  BarChart,
  Bar,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  Legend
} from "recharts";

const data = [
  {
    name: "French Fries(Peri Peri)",
    sales: 4000,
  },
  {
    name: "Chicken Crisper Burger",
    sales: 3000,
  },
  {
    name: "Veg Crisper Burger",
    sales: 2000,
  },
  {
    name: "Popcorn",
    sales: 2780,
  },
  {
    name: "Chicken Wings",
    sales: 1890,
  },
  {
    name: "Chocolate Lava",
    sales: 2390,
  },
  {
    name: "Coke",
    sales: 3490
  }
];

export default function Analytics() {
  return (
    <BarChart
      width={1500}
      height={500}
      data={data}
      margin={{
        top: 5,
        right: 30,
        left: 20,
        bottom: 5
      }}
    >
      
      <XAxis dataKey="name" />
      <YAxis />
      <Tooltip />
      <Legend />
      <Bar dataKey="sales" fill="#82ca9d" />
    </BarChart>
  );
}


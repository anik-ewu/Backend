const mongoose = require("mongoose");
const dotenv = require("dotenv");

dotenv.config();

const Product = require("./models/product");
const Cart = require("./models/cart");
const Order = require("./models/order");
const User = require("./models/users"); // Assuming you have a User model

mongoose
  .connect(process.env.MONGO_URI, { useNewUrlParser: true, useUnifiedTopology: true })
  .then(() => console.log("MongoDB Connected"))
  .catch((err) => console.log("DB Connection Error: ", err));

const seedUsers = async () => {
  await User.deleteMany({});
  const users = await User.insertMany([
    { username: "john_doe", email: "john@example.com", password: "password123", role: "customer" },
    { username: "jane_doe", email: "jane@example.com", password: "password123", role: "customer" },
    { username: "admin_user", email: "admin@example.com", password: "admin123", role: "admin" },
  ]);
  console.log("✅ Users Seeded:", users);
};

const seedProducts = async () => {
  await Product.deleteMany({});
  const products = await Product.insertMany([
    { name: "iPhone 15", description: "Latest Apple iPhone", price: 999, category: "Electronics", stock: 10 },
    { name: "MacBook Air", description: "Apple M2 MacBook", price: 1299, category: "Electronics", stock: 5 },
    { name: "Nike Shoes", description: "Running Shoes", price: 120, category: "Fashion", stock: 20 },
    { name: "Samsung Galaxy S23", description: "Latest Samsung Smartphone", price: 899, category: "Electronics", stock: 15 },
    { name: "Leather Jacket", description: "Stylish Leather Jacket", price: 250, category: "Fashion", stock: 8 },
  ]);
  console.log("✅ Products Seeded:", products);
};

const seedCarts = async () => {
  await Cart.deleteMany({});
  const carts = await Cart.insertMany([
    {
      userId: "60c72b2f4f1a2c001c8d5f1f", // Example user ID
      products: [
        { productId: "60c72b2f4f1a2c001c8d5f20", quantity: 2 }, // Example product ID
        { productId: "60c72b2f4f1a2c001c8d5f21", quantity: 1 },
      ],
    },
    {
      userId: "60c72b2f4f1a2c001c8d5f22", // Another user ID
      products: [
        { productId: "60c72b2f4f1a2c001c8d5f22", quantity: 1 },
        { productId: "60c72b2f4f1a2c001c8d5f23", quantity: 3 },
      ],
    },
  ]);
  console.log("✅ Carts Seeded:", carts);
};

const seedOrders = async () => {
  await Order.deleteMany({});
  const orders = await Order.insertMany([
    {
      userId: "60c72b2f4f1a2c001c8d5f1f", // Example user ID
      products: [
        { productId: "60c72b2f4f1a2c001c8d5f20", quantity: 1, price: 999 },
        { productId: "60c72b2f4f1a2c001c8d5f21", quantity: 2, price: 120 },
      ],
      totalAmount: 1239, // Calculate total
      status: "Pending",
    },
    {
      userId: "60c72b2f4f1a2c001c8d5f22", // Another user ID
      products: [
        { productId: "60c72b2f4f1a2c001c8d5f22", quantity: 1, price: 250 },
      ],
      totalAmount: 250,
      status: "Shipped",
    },
  ]);
  console.log("✅ Orders Seeded:", orders);
};

const seedDatabase = async () => {
  await seedUsers();
  await seedProducts();
  await seedCarts();
  await seedOrders();
  mongoose.connection.close();
};

seedDatabase();

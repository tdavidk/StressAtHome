<?php
    $server = "localhost";
    $username = "root";
    $password = "root";
    $db = "stress_at_home";

    $conn = new mysqli($server, $username, $password, $db);

    // Check connection
    if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    } 
    
?>
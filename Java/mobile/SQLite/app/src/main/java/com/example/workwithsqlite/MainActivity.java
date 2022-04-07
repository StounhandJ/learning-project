package com.example.workwithsqlite;

import androidx.appcompat.app.AppCompatActivity;

import android.app.AlertDialog;
import android.database.Cursor;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    EditText name, phone, dateOfBirth;
    Button insert, select, delete, update;
    DatabaseHelper dataBaseHelper;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        name = findViewById(R.id.txtName);
        phone = findViewById(R.id.txtNumber);
        dateOfBirth = findViewById(R.id.txtDate);
        insert = findViewById(R.id.btnInsert);
        select = findViewById(R.id.btnSelect);
        delete = findViewById(R.id.btnDelete);
        update = findViewById(R.id.btnUpdate);
        dataBaseHelper = new DatabaseHelper(this);

        delete.setOnClickListener(view -> {
            Boolean checkInsertData = dataBaseHelper.delete(name.getText().toString());
            if (checkInsertData) {
                Toast.makeText(getApplicationContext(), "Пользователь успешно удалён", Toast.LENGTH_LONG).show();
            } else {
                Toast.makeText(getApplicationContext(), "Произошла ошибка", Toast.LENGTH_LONG).show();
            }
        });

            insert.setOnClickListener(view -> {
                Boolean checkInsertData = dataBaseHelper.insert(name.getText().toString(), phone.getText().toString(), dateOfBirth.getText().toString());
                if (checkInsertData) {
                    Toast.makeText(getApplicationContext(), "Данные успешно добавлены", Toast.LENGTH_LONG).show();
                } else {
                    Toast.makeText(getApplicationContext(), "Произошла ошибка", Toast.LENGTH_LONG).show();
                }
            });

        update.setOnClickListener(view -> {
            Boolean checkInsertData = dataBaseHelper.update(name.getText().toString(), phone.getText().toString(), dateOfBirth.getText().toString());
            if (checkInsertData) {
                Toast.makeText(getApplicationContext(), "Данные успешно обновлены", Toast.LENGTH_LONG).show();
            } else {
                Toast.makeText(getApplicationContext(), "Произошла ошибка", Toast.LENGTH_LONG).show();
            }
        });

        select.setOnClickListener(view -> {
            Cursor res = dataBaseHelper.getdata();
            if (res.getCount() == 0) {
                Toast.makeText(getApplicationContext(), "Нет данных", Toast.LENGTH_LONG).show();
                return;
            }

            StringBuilder buffer = new StringBuilder();
            while (res.moveToNext()) {
                buffer.append("Имя: ").append(res.getString(0)).append("\n");
                buffer.append("Тел. номер: ").append(res.getString(1)).append("\n");
                buffer.append("Дата рождения: ").append(res.getString(2)).append("\n");
            }

            AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
            builder.setCancelable(true);
            builder.setTitle("Данные пользователей");
            builder.setMessage(buffer.toString());
            builder.show();
        });
    }
}
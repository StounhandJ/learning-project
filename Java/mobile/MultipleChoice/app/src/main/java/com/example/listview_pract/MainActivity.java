package com.example.listview_pract;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.SparseBooleanArray;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.lang.reflect.Array;

public class MainActivity extends AppCompatActivity {
    ListView lst;
    String[] devices = {"Планшеты", "Телефоны", "Ноутбуки", "Компьютеры"};


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        lst = findViewById(R.id.list_view);

        ArrayAdapter<String> adapter = new ArrayAdapter<>(
                this, android.R.layout.simple_list_item_multiple_choice, devices
        );
        lst.setAdapter(adapter);

        lst.setOnItemClickListener((adapterView, view, id, l) -> {
                    SparseBooleanArray checkedItems = lst.getCheckedItemPositions();
                    StringBuilder selectedItems = new StringBuilder();
                    for (int i = 0; i < devices.length; i++) {
                        if (checkedItems.get(i)) {
                            selectedItems.append(devices[i]).append(",");
                        }
                    }
                    Toast.makeText(getApplicationContext(), selectedItems.toString(), Toast.LENGTH_SHORT).show();
                }
        );
    }
}